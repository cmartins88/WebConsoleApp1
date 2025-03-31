import { HttpClient, HttpClientModule } from '@angular/common/http';
import { Component } from '@angular/core';
import { FormsModule, NgForm } from '@angular/forms'; 
import { ActivatedRoute } from '@angular/router';
import { User } from '../models/User';

@Component({
  selector: 'app-contact',
  imports: [FormsModule, HttpClientModule],
  templateUrl: './contact.component.html',
  styleUrl: './contact.component.css'
})
export class ContactComponent {

  url = "http://localhost:5062/api"
  user:User = new User();
  
  constructor(private httpClient: HttpClient, private activatedRoute: ActivatedRoute) { }

  ngOnInit() {
    const id = this.activatedRoute.snapshot.paramMap.get('id');
    this.httpClient.get<User>(`${this.url}/Users/${id}`).subscribe(u => this.user = u);
  }

  onsubmit(f: NgForm) {
    if(!f.value.userId) {
      delete f.value.userId;
      this.httpClient.post<User>(`${this.url}/Users`, f.value).subscribe(res => {
        console.log(res);
      });
    } else {
      this.httpClient.put<User>(`${this.url}/Users`, f.value).subscribe(res => {
        console.log(res);
      });
    }
  }
}
