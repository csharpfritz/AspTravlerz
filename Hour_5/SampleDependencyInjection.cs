using Microsoft.AspNetCore.Mvc;

public class Contact {

  public string Name { get; set; }
  public string Email { get; set; }

}

public class ContactRepository {

  public Contact GetContactByEmail(string email) { return null;  }

}

public class ContactController : Controller {

  public ContactController() {}

  public Contact ContactDetails(string email) {

    var repo = new ContactRepository();
    return repo.GetContactByEmail(email);

  }
}

public class Contact2Controller : Controller {

  private ContactRepository _Repo;

  public Contact2Controller(ContactRepository repo) {
    _Repo = repo;
  }

  public Contact ContactDetails(string email) {

    return _Repo.GetContactByEmail(email);

  }
}