import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot } from '@angular/router';
import { Observable } from 'rxjs';

@Injectable({
    providedIn: 'root'
})
export class AuthGuard implements CanActivate {
    isAuthenticated = true;

    constructor(private router: Router) { }
    canActivate(route: ActivatedRouteSnapshot,
        state: RouterStateSnapshot): Observable<boolean> | Promise<boolean> | boolean {

        if (this.isAuthenticated) {
            return true;
        } else {
            this.router.navigate(['auth']);
            return false;
        }
    }
}
