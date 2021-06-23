"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var Person = /** @class */ (function () {
    function Person(Login, Password, Role) {
        if (Role === void 0) { Role = 'admin'; }
        this.Login = Login;
        this.Password = Password;
        this.Role = Role;
    }
    return Person;
}());
exports.Person = Person;
//# sourceMappingURL=person.js.map