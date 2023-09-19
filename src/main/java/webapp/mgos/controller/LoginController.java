package webapp.mgos.controller;

import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PostMapping;

@Controller
public class LoginController {

    @GetMapping("/login")
    public String showLoginPage() {
        return "login";
    }

    @PostMapping("/login")
    public String login(String email, String password) {
        if("admin@naver.com".equals(email) && "password".equals(password)) {
            return "redirect:/index";
        } else {
            return "redirect:/login?error";
        }
    }
}
