import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { User } from '../models/User';
import { Observable } from 'rxjs';
import { RouterLink } from '@angular/router';


@Component({
  selector: 'app-home',
  imports: [CommonModule, HttpClientModule, RouterLink],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent {

  constructor(private httpClient: HttpClient) { }

  url = "http://localhost:5062/api"
  title = 'World';
  name = 'Carlos';
  items = [
    { title: 'Explore the Docs', link: 'https://angular.dev' },
    { title: 'Learn with Tutorials', link: 'https://angular.dev/tutorials' },
    { title: 'CLI Docs', link: 'https://angular.dev/tools/cli' },
    { title: 'Angular Language Service', link: 'https://angular.dev/tools/language-service' },
    { title: 'Angular DevTools', link: 'https://angular.dev/tools/devtools' },
  ];
  users: User[] = [];

  ngOnInit() {
    this.getUsers().subscribe(result => this.users = result)
  }

  getUsers(): Observable<User[]> {
    return this.httpClient.get<User[]>(`${this.url}/Users`);
  }

  deleteUser(userId:string) {
    this.httpClient.delete(`${this.url}/Users/${userId}`).subscribe();
  }
    
  getContent() {
    return "jwnoewndewndowienofdwepodiwjeporieuewoidhjhooksajdkahdohdjsahldshfljdshfjhdkfjhdslksk";
  }

  handleClick() {
    alert("Obrigado");
  }
}