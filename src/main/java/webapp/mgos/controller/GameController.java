package webapp.mgos.controller;


import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;
import webapp.mgos.domain.GameData;
import webapp.mgos.request.CharacterDataRequest;
import webapp.mgos.request.GameDataRequest;
import webapp.mgos.service.GameDataService;

import java.util.List;

@RestController
@RequestMapping("/api")
public class GameController {

    @Autowired
    private GameDataService gameDataService;


    // 게임 Data 를 JSON 형태로 받아 저장
    @PostMapping("/saveGameData")
    public String saveGameData(@RequestBody GameDataRequest gameDataRequest) {
        gameDataService.saveGameData(gameDataRequest);
        return "게임 데이터가 성공적으로 저장되었습니다.";
    }


    // 모든 게임 데이터를 JSON으로 반환
    @GetMapping("/getAllGameData")
    public List<GameData> getAllGameData() {
        return gameDataService.getAllGameData();
    }


}
