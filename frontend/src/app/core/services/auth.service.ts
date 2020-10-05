import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { tap } from 'rxjs/operators';

import { environment } from '../../../environments/environment';
import { User } from '../models/user.model';
import { Router } from '@angular/router';

@Injectable({ providedIn: 'root' })
export class AuthService {
  private currentUserSubject$: BehaviorSubject<User>;
  currentUser$: Observable<User>;

  constructor(private http: HttpClient, private router: Router) {
    this.currentUserSubject$ = new BehaviorSubject<User>(
      JSON.parse(localStorage.getItem('currentUser')),
    );
    this.currentUser$ = this.currentUserSubject$.asObservable();
  }

  /** Return the logged in user. */
  public get currentUserValue(): User {
    return this.currentUserSubject$.value;
  }

  login(username: string, password: string) {
    return this.http
      .post<User>(`${environment.apiUrl}/auth/login`, {
        username,
        password,
      })
      .pipe(
        tap(user => {
          localStorage.setItem('currentUser', JSON.stringify(user));
          this.currentUserSubject$.next(user);
        }),
      );
  }

  register(username: string, password: string, country: string) {
    return this.http
      .post<User>(`${environment.apiUrl}/auth/register`, {
        username,
        password,
        country,
      })
      .pipe(
        tap(user => {
          localStorage.setItem('currentUser', JSON.stringify(user));
          this.currentUserSubject$.next(user);
        }),
      );
  }

  logout() {
    localStorage.removeItem('currentUser');
    this.currentUserSubject$.next(null);
    this.router.navigate(['auth']);
  }
}
