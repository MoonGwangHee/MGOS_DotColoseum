package webapp.mgos.service;

import lombok.RequiredArgsConstructor;
import org.springframework.stereotype.Service;
import webapp.mgos.domain.Member;
import webapp.mgos.repository.MemberRepository;

@RequiredArgsConstructor
@Service
public class MemberService {

    private final MemberRepository memberRepository;

    // 회원가입

}
