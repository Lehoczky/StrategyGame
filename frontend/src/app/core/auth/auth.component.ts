import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { first } from 'rxjs/operators';
import { AuthService } from '../services/auth.service';

@Component({
  templateUrl: './auth.component.html',
  styleUrls: ['./auth.component.scss'],
})
export class AuthComponent implements OnInit {
  @ViewChild('f', { static: false }) authForm: NgForm;

  title = 'Undersea';
  isSignUp = false;
  matchedPasswords = false;
  returnUrl: string;
  error: string;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private authenticationService: AuthService,
  ) {
    if (this.authenticationService.currentUserValue) {
      this.router.navigate(['strategy']);
    }
  }

  ngOnInit() {
    this.returnUrl = this.route.snapshot.queryParams.returnUrl || 'strategy';
  }

  get username(): string {
    return this.authForm.value.username;
  }

  get password(): string {
    return this.authForm.value.password;
  }

  get passwordAgain(): string {
    return this.authForm.value.passwordAgain;
  }

  get country(): string {
    return this.authForm.value.country;
  }

  onAuth(isSignUp: boolean): void {
    isSignUp ? this.onSignUp() : this.onLogin();
  }

  onLogin(): void {
    this.authenticationService
      .login(this.username, this.password)
      .pipe(first())
      .subscribe(
        data => {
          this.router.navigate([this.returnUrl]);
        },
        errorResponse => {
          this.error = errorResponse.error.message;
        },
      );
  }

  onSignUp(): void {
    this.authenticationService
      .register(this.username, this.password, this.country)
      .pipe(first())
      .subscribe(
        data => {
          this.router.navigate([this.returnUrl]);
        },
        errorResponse => {
          this.error = errorResponse.error.message;
        },
      );
  }

  checkPasswords(): void {
    this.matchedPasswords = this.password === this.passwordAgain;
  }

  switchForm(): void {
    this.isSignUp = !this.isSignUp;
    this.authForm.reset();
  }
}
