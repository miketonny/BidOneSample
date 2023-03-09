import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  firstName!: string;
  lastName!: string;

  constructor(private http: HttpClient, private snackBar: MatSnackBar) { }

  onSubmit() {
    const data = { firstName: this.firstName, lastName: this.lastName };
    this.http.post('/api/form', data).subscribe(() => {
      this.snackBar.open('Form submitted successfully', 'Close', {
        duration: 3000,
      });
    });
  }


}
