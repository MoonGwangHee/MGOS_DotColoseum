package webapp.mgos.controller;


import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.*;
import webapp.mgos.domain.Comment;
import webapp.mgos.service.CommentService;

import java.util.List;


@Controller
@RequestMapping("/api/comments")
public class CommentController {
    private final CommentService commentService;


    public CommentController(CommentService commentService) {
        this.commentService = commentService;
    }

}
