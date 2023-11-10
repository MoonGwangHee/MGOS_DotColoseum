package webapp.mgos.domain;

import lombok.Getter;
import lombok.Setter;

import javax.persistence.*;

@Entity
@Getter
@Setter
@Table(name = "character_data")
public class CharacterData {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "id")
    private Long id;

    @Column(name = "chara_type")
    private int charaType;

    @Column(name = "hp")
    private int hp;

    @Column(name = "atk")
    private int atk;

    @Column(name = "def")
    private int def;

    @Column(name = "agl")
    private int agl;

}
