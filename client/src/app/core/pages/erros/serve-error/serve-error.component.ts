import { Router } from '@angular/router';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-serve-error',
  templateUrl: './serve-error.component.html',
  styleUrls: ['./serve-error.component.scss']
})
export class ServeErrorComponent implements OnInit {
  error: any;

  constructor(private router: Router) {
    const navigation = this.router.getCurrentNavigation()
    this.error =navigation.extras?.state?.error;
  }

  ngOnInit(): void {
  }

}
