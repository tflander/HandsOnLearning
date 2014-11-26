import java.awt.geom.Point2D;

public class GameVector {

    final double slope;
    final double distance;
    final VectorDirection direction;

    public GameVector(final double slope, final double distance,
                      final VectorDirection direction) {
        this.slope = Double.isNaN(slope) ? 0 : slope;
        this.distance = distance;
        this.direction = direction;
    }

    public GameVector add(final GameVector additionalVector) {
        double angle1;
        final double arctanAngle1 = Math.atan(slope);
        if (direction.equals(VectorDirection.LEFT)) {
            angle1 = arctanAngle1 + Math.PI;
        } else if (arctanAngle1 < 0) {
            angle1 = arctanAngle1 + Math.PI * 2;
        } else {
            angle1 = arctanAngle1;
        }
        final double distanceY1 = Math.sin(angle1) * distance;
        final double distanceX1 = Math.cos(angle1) * distance;
        double angle;
        final Point2D thisPoint = new Point2D.Double(distanceX1, distanceY1);
        final double arctanAngle = Math.atan(additionalVector.slope);
        if (additionalVector.direction.equals(VectorDirection.LEFT)) {
            angle = arctanAngle + Math.PI;
        } else if (arctanAngle < 0) {
            angle = arctanAngle + Math.PI * 2;
        } else {
            angle = arctanAngle;
        }
        final double distanceX = Math.cos(angle) * additionalVector.distance;
        final double distanceY = Math.sin(angle) * additionalVector.distance;
        final Point2D thatPoint = new Point2D.Double(distanceX, distanceY);
        final double finalX = thisPoint.getX() + thatPoint.getX();
        final double finalY = thisPoint.getY() + thatPoint.getY();
        final double finalDistance = Math.sqrt(finalX * finalX + finalY * finalY);
        final VectorDirection figureDirection = finalX < 0 ? VectorDirection.LEFT : VectorDirection.RIGHT;
        return new GameVector(finalY / finalX, finalDistance, figureDirection);
    }


    public enum VectorDirection {RIGHT, LEFT;}
}
