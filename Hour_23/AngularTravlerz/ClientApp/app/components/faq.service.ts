import { Faq } from './faq';
import { Injectable } from '@angular/core';

@Injectable()
export class FaqService {

  private faqs: Faq[] = [ new Faq('Why did the chicken cross the road', 'to get to the other side') ];

  constructor() { }

  public Get(): Faq[] {
    return this.faqs;
  }

}
