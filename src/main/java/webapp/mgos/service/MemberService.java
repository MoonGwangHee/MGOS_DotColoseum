package webapp.mgos.service;

import lombok.RequiredArgsConstructor;
import org.springframework.stereotype.Service;
import webapp.mgos.repository.MemberRepository;

@RequiredArgsConstructor
@Service
public class MemberService {

    private final MemberRepository memberRepository;




}
