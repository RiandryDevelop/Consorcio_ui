import { SecurityService } from './../security.service';
import { Component, inject } from '@angular/core';

@Component({
  selector: 'app-authorized',
  templateUrl: './authorized.component.html',
  styleUrls: ['./authorized.component.css'],
})
export class AuthorizedComponent {
SecurityService = inject(SecurityService);

isAuthorized():boolean {
  return this.SecurityService.isLogged();
};
}
