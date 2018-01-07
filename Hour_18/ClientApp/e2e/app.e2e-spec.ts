import { MyFirstAngularAppPage } from './app.po';

describe('my-first-angular-app App', () => {
  let page: MyFirstAngularAppPage;

  beforeEach(() => {
    page = new MyFirstAngularAppPage();
  });

  it('should display welcome message', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('Welcome to app!');
  });
});
