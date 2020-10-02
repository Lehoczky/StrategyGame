import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-profile-card',
  templateUrl: './profile-card.component.html',
  styleUrls: ['./profile-card.component.scss']
})
export class ProfileCardComponent implements OnInit {

  constructor(private router: Router) { }

  ngOnInit() {
  }

  onLogout() {
    console.log('logging out...');
    this.router.navigate(['auth']);
  }

}