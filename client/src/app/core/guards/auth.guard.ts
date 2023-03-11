import { AccountService } from './../../pages/account/pages/services/account.service';
import { Injectable } from '@angular/core';
import {
  ActivatedRouteSnapshot,
  CanActivate,
  Router,
  RouterStateSnapshot,
  UrlTree,
} from '@angular/router';
import { map, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class AuthGuard implements CanActivate {
  constructor(private accountService: AccountService, private router: Router) {}

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ): Observable<boolean> {
    return this.accountService.currentUser$.pipe(
      map((auth) => {
        if (localStorage.getItem('token')) return true;
        else {
          console.log("a")
          this.router.navigate(['login'], {
            queryParams: { returnUrl: encodeURIComponent(state.url) },
          });
          return false;
        }
      })
    );
  }
}
