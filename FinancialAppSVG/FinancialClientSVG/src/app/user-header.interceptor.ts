import { HttpHeaders, HttpInterceptorFn } from '@angular/common/http';

export const userHeaderInterceptor: HttpInterceptorFn = (req, next) => {
  console.log('Intercepted!', req);
  const user = localStorage.getItem('user') || '';
  const headers = new HttpHeaders().set('user', user);
  const modifiedReq = req.clone({ headers });
  return next(modifiedReq);
};
