import  {SecurityService}  from 'src/app/security/security.service';
import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';

export const isAdminGuard: CanActivateFn = (route, state) => {
  const router = inject(Router);
  const securityService = inject(SecurityService);

  if(securityService.obtainRole() !== 'admin') {
    return false;
  }

  router.navigate(['/login']);
  
  return true;
};
