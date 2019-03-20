import {Component, OnInit} from '@angular/core';
import {HttpClient} from '@angular/common/http';

@Component({
  templateUrl: './options-named.component.html'
})
export class OptionsNamedComponent implements OnInit {
  protected model: any;
  ngOnInit(): void {
    this.httpClient
      .get('/api/options/named')
      .subscribe(data => this.model = data);
  }
  constructor(protected httpClient: HttpClient) {}
}
