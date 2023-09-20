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

    @GetMapping("/signup")
    public String showCreateAccountPage() {
        return "Signup";
    }

    @PostMapping("/signup")
    public String signUp(String email, String password, String rePassword,  String name, String cellphone) {
        // 프론트 개발을 위하여 테스트 코드 작성
        
        if("admin@naver.com".equals(email) && "password".equals(password) && "password".equals(rePassword) && "어드민".equals(name) && "111".equals(cellphone)) {
            return "redirect:/index";
        } else {
            return "redirect:/signup?error";
        }
    }

}
