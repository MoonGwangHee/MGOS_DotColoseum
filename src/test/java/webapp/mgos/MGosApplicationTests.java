package webapp.mgos;

import org.hibernate.PropertyValueException;
import org.hibernate.Session;
import org.junit.jupiter.api.Test;
import org.springframework.boot.test.context.SpringBootTest;
import webapp.mgos.domain.Comment;

import static org.assertj.core.api.AssertionsForClassTypes.assertThatThrownBy;

@SpringBootTest
class MGosApplicationTests {

	@Test
	public void testComment() {
		Comment comment = new Comment();

		Session session = null;
		assertThatThrownBy( () -> session.save(comment))
				.isInstanceOf(PropertyValueException.class)
				.hasMessageContaining("not-null property references a null or transient value");
	}

}
