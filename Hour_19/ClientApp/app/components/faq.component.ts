import { Component, OnInit } from '@angular/core';
import { FaqService } from './faq.service';
import { Faq } from './faq';

@Component({
  selector: 'app-faq',
  templateUrl: './faq.component.html',
  styleUrls: ['./faq.component.css']
})
export class FaqComponent implements OnInit {

	faqs: Faq[];

	constructor(private service: FaqService) {
	}

  ngOnInit() {
		this.faqs = this.service.Get();
  }

}
