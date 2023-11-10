package webapp.mgos.request;


import lombok.Getter;
import lombok.Setter;

@Getter
@Setter
public class GameDataRequest {
    private CharacterDataRequest first;
    private CharacterDataRequest second;
    private CharacterDataRequest third;
    private String partyName;
}
