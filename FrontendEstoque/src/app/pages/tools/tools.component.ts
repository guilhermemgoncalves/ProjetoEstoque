import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-tools',
  templateUrl: './tools.component.html',
  styleUrls: ['./tools.component.scss']
})
export class ToolsComponent implements OnInit {

  arrayTest: number[] = [1,2,3,4]

  constructor() { }

  ngOnInit(): void {

  }

}
