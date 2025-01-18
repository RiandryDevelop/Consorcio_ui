import { SecurityService } from './../security.service';
import { Component, inject, Input } from '@angular/core';

@Component({
  selector: 'app-authorized',
  templateUrl: './authorized.component.html',
  styleUrls: ['./authorized.component.css'],
})
export class AuthorizedComponent {
SecurityService = inject(SecurityService);
@Input()
role?:string

isAuthorized():boolean {
  if (this.role) {
    return this.SecurityService.obtainRole() === this.role;
  }else{
    return this.SecurityService.isLogged();
  }
};
}
