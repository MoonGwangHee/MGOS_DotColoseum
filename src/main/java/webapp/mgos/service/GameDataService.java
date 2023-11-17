package webapp.mgos.service;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import webapp.mgos.request.CharacterDataRequest;
import webapp.mgos.request.GameDataRequest;

import java.util.List;

@Service
public class GameDataService {


    @Autowired
    private GameDataRepository gameDataRepository;

    @Autowired
    private CharacterDataRepository characterDataRepository;


    public void saveGameData(GameDataRequest gameDataRequest) {


        // 캐릭터 데이터 저장
        CharacterData first = saveCharacterData(gameDataRequest.getFirst());
        CharacterData second = saveCharacterData(gameDataRequest.getSecond());
        CharacterData third = saveCharacterData(gameDataRequest.getThird());


        // 게임 데이터 저장
        GameData gameData = new GameData();

        gameData.setFirst(first);
        gameData.setSecond(second);
        gameData.setThird(third);
        gameData.setPartyName(gameDataRequest.getPartyName());

        gameDataRepository.save(gameData);
    }


    private CharacterData saveCharacterData(CharacterDataRequest characterDataRequest) {
        CharacterData characterData = new CharacterData();

        characterData.setCharaType(characterDataRequest.getCharaType());
        characterData.setHp(characterDataRequest.getHp());
        characterData.setAtk(characterDataRequest.getAtk());
        characterData.setDef(characterDataRequest.getDef());
        characterData.setAgl(characterDataRequest.getAgl());

        return characterDataRepository.save(characterData);
    }


    // 모든 게임 데이터를 JSON 형태로 반환
    public List<GameData> getAllGameData() {
        return gameDataRepository.findAll();
    }
}
