import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-pagination',
  templateUrl: './pagination.component.html',
  styleUrls: ['./pagination.component.scss']
})
export class PaginationComponent implements OnInit {

  @Input() pageNumber: number = 1;
  @Input() pageSize: number = 0;
  @Input() totalCount: number;
  @Output() pageChanged = new EventEmitter<number>();

  constructor() { }

  ngOnInit(): void {
  }

  onPageChanged(page: number)
  {
    this.pageNumber = page
    this.pageChanged.emit(page);
  }
}
