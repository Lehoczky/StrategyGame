import { Component } from '@angular/core';
import { AuthService } from '../../services/auth.service';

@Component({
  selector: 'app-profile-card',
  templateUrl: './profile-card.component.html',
  styleUrls: ['./profile-card.component.scss'],
})
export class ProfileCardComponent {
  user$ = this.authenticationService.currentUser$;

  constructor(private authenticationService: AuthService) {}

  onLogout(): void {
    this.authenticationService.logout();
  }
}
