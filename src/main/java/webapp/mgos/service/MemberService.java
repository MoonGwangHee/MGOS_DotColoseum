package webapp.mgos.service;

import lombok.RequiredArgsConstructor;
import org.springframework.stereotype.Service;
import webapp.mgos.repository.MemberRepository;

@RequiredArgsConstructor
@Service
public class MemberService {

    private final MemberRepository memberRepository;

    public boolean validateAccount(String email, String password) {

        // 이메일 규칙 확인
        if(!email.contains("@")) {
            return false;
        }

        // 비밀번호 규칙 확인
        if (password.length() < 8 || !password.matches("!@#$%^&*")) {
            return false;
        }
        return true;
    }


}
