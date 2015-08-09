function AppViewModel() {
    var self = this;

    self.name = ko.observable("");
    self.email = ko.observable("");
    self.message = ko.observable("");
    self.submitMessage = ko.computed(function () {
        if (self.name().length != 0) {
            document.getElementById("submitInfo").innerHTML = "";
            return "Hello, " + self.name() + "! When you are ready, please click the \"Submit\" button to send us your message.";
        } else {
            return "";
        }
    }, self);

    self.clearFields = function () {
        self.name("");
        self.email("");
        self.message("");
        document.getElementById("nameMsg").innerHTML = "";
        document.getElementById("emailMsg").innerHTML = "";
        document.getElementById("messageMsg").innerHTML = "";
        document.getElementById("submitInfo").innerHTML = "";
    };
}

ko.applyBindings(new AppViewModel());