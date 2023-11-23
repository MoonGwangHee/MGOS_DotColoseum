package webapp.mgos.controller;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.security.crypto.bcrypt.BCryptPasswordEncoder;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.servlet.mvc.support.RedirectAttributes;
import webapp.mgos.domain.Member;
import webapp.mgos.repository.MemberRepository;
import webapp.mgos.service.MemberService;

import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpSession;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

@Controller
public class LoginController {

    private final BCryptPasswordEncoder passwordEncoder;
    private final MemberService memberService;

    @Autowired
    public LoginController(BCryptPasswordEncoder passwordEncoder, MemberRepository memberRepository, MemberService memberService) {
        this.passwordEncoder = passwordEncoder;
        this.memberRepository = memberRepository;
        this.memberService = memberService;
    }

    /**
     * 로그인 관련 폼 & 메서드
     */

    @Autowired
    private HttpSession httpSession;

    
    @GetMapping("/login")
    public String showLoginPage() {
        return "login";
    }

    @PostMapping("/login")
    public String login(String email, String password, RedirectAttributes redirectAttributes) {
        Member member = memberRepository.findByEmail(email);

        if(member != null && passwordEncoder.matches(password, member.getPassword())) {

            // 로그인 성공 세션에 사용자 정보 저장
            httpSession.setAttribute("user", email);
            return "redirect:/game";

        } else {

            // 로그인 실패
            Member existingMember = memberRepository.findByEmail(email);

            if(existingMember == null) {
                redirectAttributes.addFlashAttribute("loginError", "이메일이 존재하지 않습니다.");
            } else {
                redirectAttributes.addFlashAttribute("loginError", "비밀번호가 올바르지 않습니다.");
            }
        }
        return "redirect:/login";
    }


    // 로그아웃
    @PostMapping("/logout")
    public String logout(HttpServletRequest request) {
        // 세션을 삭제
        HttpSession session = request.getSession(false);
        // 세션이 null 이 아니라면, session.invalidate() 로 세션 삭제
        if(session != null) {
            session.invalidate();
        }
        return "redirect:/login";
    }


    

    /**
     * 회원가입 관련 폼 & 메서드
     */

    // 회원가입 관련

    private final MemberRepository memberRepository;



    // Signup 페이지로 이동
    @GetMapping("/signup")
    public String showCreateAccountPage() {
        return "Signup";
    }


    @PostMapping("/signup")
    public String signUp(Member member, RedirectAttributes redirectAttributes) {
        String email = member.getEmail();
        String password = member.getPassword();

        // 이메일 중복 확인
        Member existingEmail = memberRepository.findByEmail(member.getEmail());


        if(existingEmail != null) {
            redirectAttributes.addFlashAttribute("signupError", "이미 사용중인 이메일 입니다.");
            return "redirect:/signup";
        }

        // 비밀번호 암호화
        String encodedPassword = passwordEncoder.encode(member.getPassword());
        member.setPassword(encodedPassword);

        // 회원 정보를 DB에 저장
        memberRepository.save(member);

        return "redirect:/login";
        
    }


    /**
     * 게임 페이지 관련 메서드 & 폼
     */

    @GetMapping("/game")
    public String gamePage(HttpServletRequest request) {
        if(request.getSession().getAttribute("user") == null) {
            // 로그인되지 않았으므로 로그인 페이지로 리다이렉트
            return "redirect:/login";
        }

        // 로그인된 사용자만 게임 페이지로 이동할 수 있음
         return "game";
    }




    /**
     * 서버에서 이메일 중복 확인을 수행하는 로직
     */

    @GetMapping("/check-email")
    public ResponseEntity<String> checkEmail(@RequestParam String email) {
        boolean isEmailExists = memberRepository.existsByEmail(email);


        if (isEmailExists) {
            return ResponseEntity.badRequest().body("이미 사용중인 이메일입니다.");
        } else {
            return ResponseEntity.ok("사용 가능한 이메일입니다.");
        }
    }

}




