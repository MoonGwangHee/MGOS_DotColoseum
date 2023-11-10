package webapp.mgos.repository;

import org.springframework.data.jpa.repository.JpaRepository;
import webapp.mgos.domain.GameData;

public interface GameDataRepository extends JpaRepository<GameData, Long> {
    
    // 추가적인 쿼리 메소드 작성
}
