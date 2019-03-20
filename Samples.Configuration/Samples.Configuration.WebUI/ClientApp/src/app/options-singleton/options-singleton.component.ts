import {Component, OnInit} from '@angular/core';
import {HttpClient} from '@angular/common/http';

@Component({
  templateUrl: './options-singleton.component.html'
})
export class OptionsSingletonComponent implements OnInit {
  protected model: any;
  ngOnInit(): void {
    this.httpClient
      .get('/api/options/singleton')
      .subscribe(data => this.model = data);
  }
  constructor(protected httpClient: HttpClient) {}
}
