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

@Controller
public class LoginController {

    private final BCryptPasswordEncoder passwordEncoder;

    @Autowired
    public LoginController(BCryptPasswordEncoder passwordEncoder, MemberRepository memberRepository) {
        this.passwordEncoder = passwordEncoder;
        this.memberRepository = memberRepository;
    }

    /**
     * 로그인 관련 폼 & 메서드
     */
    
    @GetMapping("/login")
    public String showLoginPage() {
        return "login";
    }

    @PostMapping("/login")
    public String login(String email, String password, RedirectAttributes redirectAttributes) {
        Member member = memberRepository.findByEmail(email);

        if(member != null && passwordEncoder.matches(password, member.getPassword())) {

            // 로그인 성공
            return "redirect:/index";
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
