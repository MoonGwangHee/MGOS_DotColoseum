package webapp.mgos.service;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import webapp.mgos.domain.Comment;
import webapp.mgos.repository.CommentRepository;

import java.time.LocalDateTime;
import java.util.List;

@Service
public class CommentService {
    private final CommentRepository commentRepository;

    @Autowired
    public CommentService(CommentRepository commentRepository) {
        this.commentRepository = commentRepository;
    }


    public List<Comment> getAllComments() {
        return commentRepository.findAllByOrderByCreatedAtDesc();
    }

    public Comment saveComment(Comment comment) {
        // 댓글 저장 로직 추가
        return commentRepository.save(comment);
    }
}
