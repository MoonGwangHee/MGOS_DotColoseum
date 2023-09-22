package webapp.mgos.repository;

import org.springframework.data.jpa.repository.JpaRepository;
import webapp.mgos.domain.Member;

import java.util.List;

public interface MemberRepository extends JpaRepository<Member, Long> {
    Member findByEmail(String email); // 이메일을 통한 user 조회
    
    List<Member> findAll(); // 전체 조회
}
