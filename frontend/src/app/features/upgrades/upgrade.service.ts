import { Injectable } from '@angular/core';
import { BehaviorSubject, combineLatest } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { AuthService } from '../../core/services/auth.service';
import { filter, map, switchMap } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { Upgrade } from './upgrade.model';

@Injectable({
  providedIn: 'root',
})
export class UpgradeService {
  private upgradesUrl = `${environment.apiUrl}/upgrades`;
  private types$ = new BehaviorSubject<Array<Upgrade>>([]);
  private upgradesSubject$ = new BehaviorSubject<Array<number>>([]);

  researchedUpgrades$ = this.upgradesSubject$.asObservable();
  upgrades$ = combineLatest(this.types$, this.researchedUpgrades$).pipe(
    map(([upgrades, researched]) => {
      return upgrades.map(upgrade => {
        const owned = researched.includes(upgrade.id);
        return { ...upgrade, owned } as Upgrade;
      });
    }),
  );

  constructor(
    private http: HttpClient,
    private authenticationService: AuthService,
  ) {
    this.authenticationService.currentUser$
      .pipe(
        filter(user => user !== null),
        switchMap(_ => this.fetchUpgrades()),
        map(upgrades => upgrades.map(entry => entry.upgradeId)),
      )
      .subscribe(upgrades => {
        this.upgradesSubject$.next(upgrades);
      });

    this.fetchTypes().subscribe(upgrades => {
      this.types$.next(upgrades);
    });
  }

  purchaseUpgrade(upgrade: Upgrade) {
    this.http.post(this.upgradesUrl, { name: upgrade.name }).subscribe(() => {
      const state = this.upgradesSubject$.getValue();
      this.upgradesSubject$.next([...state, upgrade.id]);
    });
  }

  private fetchTypes() {
    return this.http.get<Array<Upgrade>>(this.upgradesUrl + '/types');
  }

  private fetchUpgrades() {
    return this.http.get<Array<{ upgradeId: number }>>(this.upgradesUrl);
  }
}
