package webapp.mgos.controller;

import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PostMapping;
import webapp.mgos.domain.Member;
import webapp.mgos.repository.MemberRepository;

@Controller
public class LoginController {


    /**
     * 로그인 관련 폼 & 메서드
     */
    
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


    

    /**
     * 회원가입 관련 폼 & 메서드
     */

    // 회원가입 관련
    public LoginController(MemberRepository memberRepository) {
        this.memberRepository = memberRepository;
    }

    private final MemberRepository memberRepository;


    
    // Signup 페이지로 이동
    @GetMapping("/signup")
    public String showCreateAccountPage() {
        return "Signup";
    }


    @PostMapping("/signup")
    public String signUp(Member member) {
        // 회원 정보를 DB에 저장
        memberRepository.save(member);
        return "redirect:/login";
        
    }

}
