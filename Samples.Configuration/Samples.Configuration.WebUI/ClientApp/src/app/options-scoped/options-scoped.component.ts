import {Component, OnInit} from '@angular/core';
import {HttpClient} from '@angular/common/http';

@Component({
  templateUrl: './options-scoped.component.html'
})
export class OptionsScopedComponent implements OnInit {
  protected model: any;
  ngOnInit(): void {
    this.httpClient
      .get('/api/options/scoped')
      .subscribe(data => this.model = data);
  }
  constructor(protected httpClient: HttpClient) {}
}
