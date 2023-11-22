package webapp.mgos.controller;


import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.*;
import webapp.mgos.domain.Comment;
import webapp.mgos.service.CommentService;

import javax.servlet.http.HttpServletResponse;
import java.io.IOException;
import java.util.List;


@RestController
@RequestMapping("/api/comments")
public class CommentController {
    private final CommentService commentService;


    public CommentController(CommentService commentService) {
        this.commentService = commentService;
    }

    @PostMapping("/comments")
    public String showComments(Model model) {
        List<Comment> comments = commentService.getAllComments();
        model.addAttribute("comments", comments);
        return "comments";
    }


    @PostMapping("/add")
    public void addContent(@ModelAttribute Comment comment , HttpServletResponse response) {
        commentService.saveComment(comment);
        String redirect_url="http://localhost:8080/index";
        try {
            response.sendRedirect(redirect_url);
        } catch (IOException e) {
            throw new RuntimeException(e);
        }
    }

    @GetMapping
    public List<Comment> getAllComments() {
        return commentService.getAllComments();
    }

}
