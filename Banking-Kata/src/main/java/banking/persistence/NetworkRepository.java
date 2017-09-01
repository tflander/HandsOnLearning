package banking.persistence;

import java.util.HashMap;
import java.util.Optional;
import java.util.Random;
import java.util.UUID;

import banking.model.Identifiable;

public class NetworkRepository<T extends Identifiable> implements Repository<T> {

	private final Random random = new Random();

	private final HashMap<UUID, T> items = new HashMap<UUID, T>();

	@Override
	public Optional<T> findOne(final UUID id) {
		randomlyExplodeSlowly();
		return Optional.of(items.get(id));
	}

	@Override
	public void save(T item) {
		randomlyExplodeSlowly();
		items.put(item.getId(), item);
	}

	private void randomlyExplodeSlowly() {
		try {
			final int sleepTime = random.nextInt(2000) + 3000;
			Thread.sleep(sleepTime);
		} catch (final InterruptedException e) {
			e.printStackTrace();
		}
		final boolean willExplode = random.nextDouble() < 0.1;
		if (willExplode) {
			throw new RuntimeException("The network repository has exploded.");
		}
	}

}
