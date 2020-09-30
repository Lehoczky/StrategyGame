import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';

@Component({
  templateUrl: './auth.page.component.html',
  styleUrls: ['./auth.page.component.scss']
})
export class AuthPageComponent implements OnInit {

  @ViewChild('f', { static: false }) authForm: NgForm;
  title = 'Undersea';
  isSignUp = false;
  matchedPasswords = false;

  constructor() { }

  ngOnInit() {
  }

  onAuth(isSignUp) {
    isSignUp ? this.onSignUp() : this.onLogin();
  }

  onLogin() {
    console.log('logging in...')
  }

  onSignUp() {
    console.log('signing up...')
  }

  checkPasswords() {
    this.matchedPasswords = this.authForm.value.password === this.authForm.value.passwordAgain ? true : false;
  }

  switchForm() {
    this.isSignUp=!this.isSignUp;
    this.authForm.reset();
  }

}
