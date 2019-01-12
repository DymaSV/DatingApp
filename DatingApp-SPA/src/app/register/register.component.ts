import { Component, OnInit, Input, EventEmitter, Output } from '@angular/core';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  model: any = {};
  @Output() cancelEvent: EventEmitter<boolean> = new EventEmitter();
  constructor(private authService: AuthService) {}

  ngOnInit() {}

  register() {
    this.authService.register(this.model).subscribe(
      () => {
        console.log('Register success');
      },
      error => {
        console.log(error);
      }
    );
  }

  cancel() {
    this.cancelEvent.emit(false);
    console.log(this.model);
  }
}
