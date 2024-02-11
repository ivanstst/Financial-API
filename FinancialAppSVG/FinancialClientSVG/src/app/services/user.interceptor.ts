import { Injectable } from '@angular/core';
import { HttpInterceptor, HttpRequest, HttpHandler, HttpHeaders } from '@angular/common/http';

@Injectable()
export class UserInterceptor implements HttpInterceptor {
  intercept(req: HttpRequest<any>, next: HttpHandler) {
    const user = localStorage.getItem('user') || '';
    const headers = new HttpHeaders().set('user', user);
    const modifiedReq = req.clone({ headers });
    return next.handle(modifiedReq);
  }
}