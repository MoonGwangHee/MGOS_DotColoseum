package webapp.mgos.repository;

import org.springframework.data.jpa.repository.JpaRepository;
import webapp.mgos.domain.CharacterData;

public interface CharacterDataRepository extends JpaRepository<CharacterData, Long> {
}
