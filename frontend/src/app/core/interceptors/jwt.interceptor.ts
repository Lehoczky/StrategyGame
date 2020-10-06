import {
  HttpEvent,
  HttpHandler,
  HttpInterceptor,
  HttpRequest,
} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

import { AuthService } from '../services/auth.service';

/**
 * Interceptor which automatically puts the user's JWT
 * token to the request header.
 */
@Injectable()
export class JwtInterceptor implements HttpInterceptor {
  constructor(private authenticationService: AuthService) {}

  intercept(
    request: HttpRequest<any>,
    next: HttpHandler,
  ): Observable<HttpEvent<any>> {
    const currentUser = this.authenticationService.currentUserValue;
    if (currentUser && currentUser.access) {
      request = request.clone({
        setHeaders: {
          Authorization: `Bearer ${currentUser.access}`,
        },
      });
    }

    return next.handle(request);
  }
}
