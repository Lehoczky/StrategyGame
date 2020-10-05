import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../../services/auth.service';

@Component({
  selector: 'app-profile-card',
  templateUrl: './profile-card.component.html',
  styleUrls: ['./profile-card.component.scss'],
})
export class ProfileCardComponent {
  constructor(
    private router: Router,
    private authenticationService: AuthService,
  ) {}

  onLogout(): void {
    this.authenticationService.logout();
  }
}
