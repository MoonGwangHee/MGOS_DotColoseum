package webapp.mgos.domain;

import lombok.Getter;
import lombok.Setter;

import javax.persistence.*;

@Entity
@Getter
@Setter
@Table(name = "game_data")
public class GameData {
    
    // 추후에 데이터 포맷 받으면 값 설정
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "id")
    private Long id;

    @ManyToOne(cascade = CascadeType.ALL)
    @JoinColumn(name = "first_id")
    private CharacterData first;

    @ManyToOne(cascade = CascadeType.ALL)
    @JoinColumn(name = "second_id")
    private CharacterData second;

    @ManyToOne(cascade = CascadeType.ALL)
    @JoinColumn(name = "third_id")
    private CharacterData third;

    @Column(name = "party_name")
    private String partyName;
}
