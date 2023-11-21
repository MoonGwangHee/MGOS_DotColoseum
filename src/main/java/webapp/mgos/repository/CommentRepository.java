package webapp.mgos.repository;

import org.springframework.data.jpa.repository.JpaRepository;
import webapp.mgos.domain.Comment;

import java.util.List;

public interface CommentRepository extends JpaRepository<Comment, Long> {

    List<Comment> findAllByOrderByCreatedAtDesc();
}
