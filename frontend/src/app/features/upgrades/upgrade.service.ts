import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { AuthService } from '../../core/services/auth.service';
import { tap, filter, switchMap, map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { Upgrade } from './upgrade.model';

class UpgradesState {
  mudTractor: boolean;
  mudCombine: boolean;
  coralWall: boolean;
  sonarCannon: boolean;
  undergroundMartialArts: boolean;
  alchemy: boolean;
}

const initalState: UpgradesState = {
  mudTractor: false,
  mudCombine: false,
  coralWall: false,
  sonarCannon: false,
  undergroundMartialArts: false,
  alchemy: false,
};

@Injectable({
  providedIn: 'root',
})
export class UpgradeService {
  private upgradesSubject$ = new BehaviorSubject<UpgradesState>(initalState);
  upgrades$ = this.upgradesSubject$.asObservable();
  upgradesWithDescription$ = this.upgrades$.pipe(
    map(upgrades => {
      return [
        {
          name: 'Iszaptraktor',
          typeName: 'mudTractor',
          coralBonus: 10,
          defenseBonus: 0,
          attackBonus: 0,
          taxBonus: 0,
          img: '../../../../../assets/img/undersea_game-09.png',
          description: 'növeli a korall termesztését 10%-kal',
          owned: upgrades.mudTractor,
        },
        {
          name: 'Iszapkombájn',
          typeName: 'mudCombine',
          coralBonus: 15,
          defenseBonus: 0,
          attackBonus: 0,
          taxBonus: 0,
          img: '../../../../../assets/img/undersea_game-10.png',
          description: 'növeli a korall termesztését 15%-kal',
          owned: upgrades.mudCombine,
        },
        {
          name: 'Korallfal',
          typeName: 'coralWall',
          coralBonus: 0,
          defenseBonus: 20,
          attackBonus: 0,
          taxBonus: 0,
          img: '../../../../../assets/img/undersea_game-03.png',
          description: 'növeli a védelmi pontokat 20%-kal',
          owned: upgrades.coralWall,
        },
        {
          name: 'Szonárágyú',
          typeName: 'sonarCannon',
          coralBonus: 10,
          defenseBonus: 0,
          attackBonus: 20,
          taxBonus: 0,
          img: '../../../../../assets/img/undersea_game-03.png',
          description: 'növeli a támadópontokat 20%-kal',
          owned: upgrades.sonarCannon,
        },
        {
          name: 'Vízalatti harcművészetek',
          typeName: 'undergroundMartialArts',
          coralBonus: 0,
          defenseBonus: 10,
          attackBonus: 10,
          taxBonus: 0,
          img: '../../../../../assets/img/undersea_game-03.png',
          description: 'növeli a védelmi és támadóerőt 10%-kal',
          owned: upgrades.undergroundMartialArts,
        },
        {
          name: 'Alkímia',
          typeName: 'alchemy',
          coralBonus: 0,
          defenseBonus: 0,
          attackBonus: 0,
          taxBonus: 30,
          img: '../../../../../assets/img/undersea_game-03.png',
          description: 'növeli a beszedett adót 30%-kal',
          owned: upgrades.alchemy,
        },
      ] as Array<Upgrade>;
    }),
  );

  private upgradesUrl = `${environment.apiUrl}/upgrades`;

  constructor(
    private http: HttpClient,
    private authenticationService: AuthService,
  ) {
    this.authenticationService.currentUser$
      .pipe(
        filter(user => user !== null),
        switchMap(_ => this.fetchUpgrades()),
        map(this.findResearchedUpgrades),
      )
      .subscribe(upgrades => {
        console.log(upgrades);

        this.upgradesSubject$.next(upgrades);
      });
  }

  purchaseUpgrade(upgrade: string) {
    this.http.post(this.upgradesUrl, { name: upgrade }).subscribe(() => {
      const currentState = this.upgradesSubject$.getValue();
      const newState = {
        ...currentState,
        [upgrade]: true,
      };
      console.log(newState);

      this.upgradesSubject$.next(newState);
    });
  }

  private fetchUpgrades() {
    return this.http.get(this.upgradesUrl);
  }

  private findResearchedUpgrades(upgrades): UpgradesState {
    const researched = { ...initalState };
    for (const upgrade of upgrades) {
      switch (upgrade.name) {
        case 'iszaptraktor':
          researched.mudTractor = true;
          break;
        case 'iszapkombájn':
          researched.mudCombine = true;
          break;
        case 'korallfal':
          researched.coralWall = true;
          break;
        case 'szonár ágyú':
          researched.sonarCannon = true;
          break;
        case 'vízalatti harcművészetek':
          researched.undergroundMartialArts = true;
          break;
        case 'alkímia':
          researched.alchemy = true;
          break;
      }
    }
    return researched;
  }
}
