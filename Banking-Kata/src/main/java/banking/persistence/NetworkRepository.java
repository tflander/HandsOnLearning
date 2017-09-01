package banking.persistence;

import banking.model.Identifiable;

import java.util.HashMap;
import java.util.Optional;
import java.util.Random;
import java.util.UUID;

public class NetworkRepository<T extends Identifiable> implements Repository<T> {

	private final Random random = new Random();

	private final HashMap<UUID, T> items = new HashMap<UUID, T>();

	@Override
	public Optional<T> findOne(final UUID id) {
		randomlyExplodeSlowly();
		return Optional.ofNullable(items.get(id));
	}

	@Override
	public void save(T item) {
		randomlyExplodeSlowly();
		items.put(item.getId(), item);
	}

	private void randomlyExplodeSlowly() {
		try {
			final int sleepTime = random.nextInt(2000) + 1000;
			Thread.sleep(sleepTime);
		} catch (final InterruptedException e) {
			e.printStackTrace();
		}
		final boolean willExplode = random.nextDouble() < 0.04;
		if (willExplode) {
			throw new RuntimeException("The network repository has exploded.");
		}
	}

}
