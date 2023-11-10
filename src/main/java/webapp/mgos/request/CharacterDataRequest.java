package webapp.mgos.request;


import lombok.Getter;
import lombok.Setter;

@Getter
@Setter
public class CharacterDataRequest {

    private int charaType;
    private int hp;
    private int atk;
    private int def;
    private int agl;
}
